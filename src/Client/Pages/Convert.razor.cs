namespace Chameleon.Client.Pages
{
    public partial class Convert
    {
        [Inject] private HttpClient Http { get; set; }
        [Inject] private ILogger<Convert> logger { get; set; }
        private List<File> files = new();
        private List<UploadResult> uploadResults = new();
        private int maxAllowedFiles = 3;
        private bool shouldRender;

        protected override bool ShouldRender() => shouldRender;

        private async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            shouldRender = false;
            long maxFileSize = 1024 * 1024 * 15;
            var upload = false;
            var MAXALLOWEDSIZE = 13512000;
            using var content = new MultipartFormDataContent();

            foreach (var file in e.GetMultipleFiles(maxAllowedFiles))
            {
                if (uploadResults.SingleOrDefault(
                    f => f.FileName == file.Name) is null)
                {
                    using var fileContent = new StreamContent(file.OpenReadStream());

                    files.Add(
                        new()
                        {
                            Name = file.Name
                        });

                    if (file.Size < maxFileSize)
                    {
                        content.Add(
                            content: fileContent,
                            name: "\"files\"",
                            fileName: file.Name);

                        upload = true;
                    }
                    else
                    {
                        logger.LogInformation("{FileName} not uploaded (Err: 6)",
                            file.Name);

                        uploadResults.Add(
                            new()
                            {
                                FileName = file.Name,
                                ErrorCode = 6,
                                Uploaded = false
                            });
                    }
                }
            }

            if (upload)
            {
                var response = await Http.PostAsync("/Filesave", content);

                var newUploadResults = await response.Content
                    .ReadFromJsonAsync<IList<UploadResult>>();

                uploadResults = uploadResults.Concat(newUploadResults).ToList();
            }

            shouldRender = true;
        }

        private static bool FileUpload(IList<UploadResult> uploadResults,
            string fileName, ILogger<Convert> logger, out UploadResult result)
        {
            result = uploadResults.SingleOrDefault(f => f.FileName == fileName);

            if (result is null)
            {
                logger.LogInformation("{FileName} not uploaded (Err: 5)", fileName);
                result = new();
                result.ErrorCode = 5;
            }

            return result.Uploaded;
        }

        private class File
        {
            public string Name { get; set; }
        }
    }

    public class UploadResult
    {
        public bool Uploaded { get; set; }
        public string FileName { get; set; }
        public string StoredFileName { get; set; }
        public int ErrorCode { get; set; }
    }
}