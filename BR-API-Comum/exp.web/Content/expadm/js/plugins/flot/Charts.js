var Theme = function () {

    var chartColors, validationRules = getValidationRules();

    // Black & Orange
    //chartColors = ["#FF9900", "#333", "#777", "#BBB", "#555", "#999", "#CCC"];

    // Ocean Breeze
    chartColors = ['#94BA65', '#2B4E72', '#2790B0', '#777', '#555', '#999', '#bbb', '#ccc', '#eee'];

    // Fire Starter
    //chartColors = ['#750000', '#F90', '#777', '#555','#002646','#999','#bbb','#ccc','#eee'];

    // Mean Green
    //chartColors = ['#5F9B43', '#DB7D1F', '#BA4139', '#777','#555','#999','#bbb','#ccc','#eee'];

    return {chartColors: chartColors};

}

var Charts = function () {

    var colors = chartColors = ['#94BA65', '#2B4E72', '#2790B0', '#00CC33', '#FF6600', '#bbb', '#bbb', '#ccc', '#eee']; //Theme.chartColors;

    return {
        vertical: vertical,
        horizontal: horizontal,
        pie: pie,
        donut: donut,
        line: line,
        lineclean: lineclean
    };

    function vertical(target, data) {
        var options = {
            colors: colors,

            grid: {
                hoverable: true,
                borderWidth: 2
            },
            bars: {
                horizontal: false,
                show: true,
                align: 'center',
                lineWidth: 0,
                fillColor: {colors: [{opacity: 1}, {opacity: 0.5}]}
            },
            legend: {
                show: true
            },

            tooltip: true,
            tooltipOpts: {
                content: '%s: %y'
            },
        };

        var el = $(target);

        if (el.length) {
            $.plot(el, data, options);
        }
    }

    function horizontal(target, data) {
        var options = {
            colors: colors,

            grid: {
                hoverable: true,
                borderWidth: 2
            },
            bars: {
                horizontal: true,
                show: true,
                align: 'center',
                barWidth: .2,
                lineWidth: 0,
                fillColor: {colors: [{opacity: 1}, {opacity: 1}]}
            },
            legend: {
                show: true
            },

            tooltip: true,
            tooltipOpts: {
                content: '%s: %y'
            },
        };

        var el = $(target);

        if (el.length) {
            $.plot(el, data, options);
        }
    }

    function pie(target, data) {
        var options = {
            colors: colors,

            series: {
                pie: {
                    show: true,
                    innerRadius: 0,
                    stroke: {
                        width: 4
                    }
                }
            },

            legend: {
                position: 'ne'
            },

            tooltip: true,
            tooltipOpts: {
                content: '%s: %y'
            },

            grid: {
                hoverable: true
            }
        };

        var el = $(target);

        if (el.length) {
            $.plot(el, data, options);
        }
    }

    function donut(target, data) {
        var options = {
            colors: colors,

            series: {
                pie: {
                    show: true,
                    innerRadius: .5,
                    stroke: {
                        width: 4
                    }
                }
            },

            legend: {
                position: 'ne'
            },

            tooltip: true,
            tooltipOpts: {
                content: '%s: %y'
            },

            grid: {
                hoverable: true
            }
        };

        var el = $(target);

        if (el.length) {
            $.plot(el, data, options);
        }
    }

    function line(target, data) {
        var options = {
            colors: colors,
            series: {
                lines: {
                    show: true,
                    fill: true,
                    lineWidth: 1,
                    steps: false,
                    fillColor: {colors: [{opacity: 0.4}, {opacity: 0}]}
                },
                points: {
                    show: true,
                    radius: 4,
                    fill: true
                }
            },
            legend: {
                position: 'ne'
            },
            tooltip: true,
            tooltipOpts: {
                content: '%s: %y'
            },
            grid: {borderWidth: 1, hoverable: true}
        };
        var el = $(target);
        if (el.length) {
            $.plot(el, data, options);
        }
    }


    function lineclean(target, data) {
        var options = {
            colors: colors,
            series: {
                lines: {
                    show: true,
                    fill: false,
                    lineWidth: 1,
                    steps: false,
                    fillColor: {colors: [{opacity: 0.4}, {opacity: 0}]}
                },
                points: {
                    show: true,
                    radius: 4,
                    fill: false
                }
            },
            legend: {
                position: 'ne'
            },
            tooltip: true,
            tooltipOpts: {
                content: '%s: %y'
            },
            grid: {borderWidth: 1, hoverable: true}
        };
        var el = $(target);
        if (el.length) {
            $.plot(el, data, options);
        }
    }

}();