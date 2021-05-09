import chart from 'chart.js';
import { getCurrentTime } from './time_lib';




export function GetCurrentTime() {
    return getCurrentTime();
}

export function Chart () {
    return chart();
}
