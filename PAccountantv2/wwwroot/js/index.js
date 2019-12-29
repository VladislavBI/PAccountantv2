const url = 'http://localhost:51289/api';
let mementos = [];
let chat = {};
let chartData = {};
let chartDataProvider = [];
let elementIndex = -1;
let problemIndex = -1;

$.get(`${url}/wheel`, function (data) {
    chartData = data;
    createWheel(chartData);
    wheelSetData(data);
    prerenderWheel(chartData);
});

$.get(`${url}/wheel/memento`, function (data) {
    mementos = data;
    for (var index in data) {
        var date = new Date(data[index].date);
        $('.memento-list').append(`<div class="date" onClick='getWheel(${index})'>${date.toDateString()}: ${data[index].totalScore}</div>`);
    }
});

getWheel = function (index) {
    var date = new Date(mementos[index].date);
    var formattedDate = `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`;

    $.get(`${url}/wheel?wheelDate=${formattedDate}`, function (data) {
        wheelSetData(data);
        chartData = data;
        prerenderWheel(chartData);
    });
}

createWheel = function (data) {
    chart = AmCharts.makeChart("chartdiv", {
        "type": "radar",
        "theme": "light",
        "dataProvider": chartDataProvider,
        "valueAxes": [{
            "gridType": "circles",
            "axisTitleOffset": 20,
            "minimum": 0,
            "maximum": 10,
            "axisAlpha": 0.15,
            "guides": [
                {},
                {},
                {},
                {},
                {},
                {},
                {},
                {}
            ]
        }],
        "graphs": [{}],
        "categoryField": "country"
    });


}

wheelSetData = function (data) {
    chartDataProvider = data.map(d => ({ country: d.name }));
    chart.dataProvider = chartDataProvider;
}
prerenderWheel = function (data) {
    $('.row1').empty();
    $('.row2').empty();
    $('.row3').empty();

    for (var i = 0; i < 8; i++) {
        let element = data[i];
        let problems = element.problems.filter(x => !x.isFinished);

        setValue(i, element.score);
        if (i < 3) {
            $('.row1').append(`<div class="col dt${i}" style='border: 5px solid black;'>${element.id}) ${element.name} ${element.score}<div class="row prList${i}" style="display: block;"></div></div>`);

            for (var j = 0; j < problems.length; j++) {
                elementIndex = i;
                addProblem(problems[j]);
            }
            continue;
        }

        if (i < 6) {
            $('.row2').append(`<div class="col dt${i}" style='border: 5px solid black;'>${element.id}) ${element.name} ${element.score}<div class="row prList${i}" style="display: block;"></div></div>`);
            for (var j = 0; j < problems.length; j++) {
                elementIndex = i;
                addProblem(problems[j]);
            }
            continue;

        }

        if (i < 8) {
            $('.row3').append(`<div class="col dt${i}" style='border: 5px solid black;'>${element.id}) ${element.name} ${element.score}<div class="row prList${i}" style="display: block;"></div></div>`);
            for (var j = 0; j < problems.length; j++) {
                elementIndex = i;
                addProblem(problems[j]);
            }
            continue;

        }
    }
}

newProblem = function(elementId) {
    elementIndex = elementId;
    $('.newProblem').show();
}

setValue = function(index, value) {

  // Init starting positions
  var startAngle = 270;
  var angle = Math.round(360 / chart.dataProvider.length);

  // Create a guide
  var guide = new AmCharts.Guide();
  guide.angle = startAngle + angle * index;
  guide.fillAlpha = 1;
  guide.fillColor = chart.colors[index];
  guide.tickLength = 0;
  guide.toAngle = guide.angle + angle;
  guide.toValue = value;
  guide.value = 0;
  guide.lineAlpha = 0;

  // Add guide
  chart.valueAxes[0].guides[index] = guide;

  // Update category
  chart.dataProvider[index]["country"] = chart.dataProvider[index]["country"].split(" ").shift() + " " + value;

  // Update chart
  chart.validateNow(true);

  // Reveal next question
  var areas = document.getElementsByClassName("area");
  for(var i = 0; i < areas.length; i++) {
    areas[i].style.display = (index + 1) === i ? "block" : "none";
  }

}

addProblem = function (problem) {
    let plans = problem.plans.filter(x => !x.isFinished);
    let inProgress = "";

    if (plans.length > 0) {
        inProgress = "in-progress";
    }
    $(`.prList${elementIndex}`).append(`<div style="margin-left:6px" class="col pr${problem.id} ${inProgress}">${problem.id}) ${problem.description}<div class="row plList${problem.id}" style="display: block;"></div></div>`);

    for (var i = 0; i < plans.length; i++) {
        problemIndex = problem.id;
        addPlan(plans[i]);
    }

}

addPlan = function (plan) {
    $(`.plList${problemIndex}`).append(`<div style="margin-left:12px" class="col pl${plan.id}">${plan.id}) ${plan.description}</div>`);
}

;