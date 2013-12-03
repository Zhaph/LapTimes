function CurrentRace(data) {
  var self = this;

  self.IsActive = ko.observable(true);

  if (!data) {
    self.IsActive(false);
    self.IsInProgress = false;
    return;
  }

  self.RaceId = data.RaceId;
  self.IsComplete = ko.observable(data.IsComplete);
  self.StartTime = ko.observable(data.StartTime);
  self.EndTime = ko.observable(data.EndTime);

  var mappedDrivers = $.map(data.Drivers, function (item) {
    return new CurrentRacer(item);
  });
  self.Drivers = ko.observableArray(mappedDrivers);

  self.State = ko.computed(function () {
    if (!self.IsComplete() && !self.StartTime()) {
      // return "ready";
      return "rgb(255, 239, 50)";
    }
    else if (!self.IsComplete()) {
      // return "gogogo";
      return "#00aa33";
    }
    else {
      // return "finished";
      return "#cc1500";
    }
  });
}

function League(data) {
  // Incoming data is now an array of drivers, each of which should have the same league.
  var self = this;
  var league = data[0].League;
  self.LeagueId = league.LeagueId;
  self.Name = ko.observable(league.Name);

  var mappedRacers = $.map(data, function (item) {
    return new Racer(item);
  });
  self.Racers = ko.observableArray(mappedRacers);
}

function CurrentRacer(data) {
  var self = this;
  self.RacerId = data.RacerId;
  self.Name = ko.observable(data.Racer.Name);
  self.Car = ko.observable(data.Car.Name);
  self.Lane = ko.observable(data.Lane);
  self.RawRaceTime = ko.observable(data.RawRaceTime);
  self.RawBestTime = ko.observable(data.Racer.RawBestTime);

  self.RaceTime = function () {
    var time = self.RawRaceTime();

    return convertTime(time);
  };
}

function Racer(data) {
  var self = this;
  self.RacerId = data.RacerId;
  self.Name = ko.observable(data.Name);
  self.RawBestTime = ko.observable(data.RawBestTime);

  self.BestTime = function () {
    var time = self.RawBestTime();

    return convertTime(time);
  };
}

function convertTime(time) {
  function addZ(n) {
    return (n < 10 ? '0' : '') + n;
  }

  function addZZ(n) {
    return (n < 100 ? '0' + addZ(n) : n);
  }

  var ms = time % 1000;
  time = (time - ms) / 1000;
  var secs = time % 60;
  time = (time - secs) / 60;
  var mins = time % 60;

  return addZ(mins) + ':' + addZ(secs) + '.' + addZZ(ms);
}

var clsStopwatch = function () {
  // Private vars
  var startAt = 0; // Time of last start / resume. (0 if not running)
  var lapTime = 0; // Time on the clock when last stopped in milliseconds
  this.isRunning = function () { return startAt > 0; };

  var now = function () {
    return (new Date()).getTime();
  };

  // Public methods
  // Start or resume
  this.start = function () {
    startAt = startAt ? startAt : now();
  };

  // Stop or pause
  this.stop = function () {
    // If running, update elapsed time otherwise keep it
    lapTime = startAt ? lapTime + now() - startAt : lapTime;
    startAt = 0; // Paused
  };

  // Reset
  this.reset = function () {
    lapTime = startAt = 0;
  };

  // Duration
  this.time = function () {
    return lapTime + (startAt ? now() - startAt : 0);
  };
};