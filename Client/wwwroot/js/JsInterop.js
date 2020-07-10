var chart;
var lineSeries;
var isInit = false;
window.setChart = (elementId) => {
    chart = LightweightCharts.createChart(document.getElementById(elementId), { width: 600, height: 400 });
    chart.applyOptions({
        timeScale: {
            rightOffset: 0,
            barSpacing: 6,
            fixLeftEdge: false,
            lockVisibleTimeRangeOnResize: false,
            rightBarStaysOnScroll: false,
            borderVisible: false,
            borderColor: '#fff000',
            visible: true,
            timeVisible: true,
            secondsVisible: true,
            //tickMarkFormatter: (time, tickMarkType, locale) => {
            //    console.log(time, tickMarkType, locale);
            //    const year = LightweightCharts.isBusinessDay(time) ? time.year : new Date(time * 1000).getUTCFullYear();
            //    return String(year);
            //},
        },
    });
    lineSeries = chart.addLineSeries();
    return "test";
};

window.addChartData = (data) => {
    if (isInit) {
        var dataJson = JSON.parse(data);
        lineSeries.update(dataJson);
    }
    else {
        var multipleDataJson = JSON.parse("["+data+"]");
        lineSeries.setData(multipleDataJson);
    }
    isInit = true;

    return data;
};
window.convertArray = (win1251Array) => {
    var win1251decoder = new TextDecoder('windows-1251');
    var bytes = new Uint8Array(win1251Array);
    var decodedArray = win1251decoder.decode(bytes);
    console.log(decodedArray);
    return decodedArray;
};