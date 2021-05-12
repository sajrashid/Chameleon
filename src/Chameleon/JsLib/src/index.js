import pieChart from './chart_lib.js';
import { getCurrentTime } from './time_lib';




export function GetCurrentTime() {
    return getCurrentTime();
}

export function Chart () {
    return pieChart();
}
