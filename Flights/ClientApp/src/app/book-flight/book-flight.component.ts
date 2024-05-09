import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FlightService } from './../api/services/flight.service'
import { FlightRm } from '../api/models'
@Component({
  selector: 'app-book-flight',
  templateUrl: './book-flight.component.html',
  styleUrls: ['./book-flight.component.css']
})
export class BookFlightComponent implements OnInit {

  flightId: string = 'not loaded';
  flight: FlightRm = {};
  constructor(private rout: ActivatedRoute,
    private flightService: FlightService,
    private router: Router) { }

  ngOnInit(): void {

    this.rout.paramMap
      .subscribe(p => this.findFlight (p.get("flightId")))
  }

  private findFlight = (flightId: string | null) => {
    this.flightId = flightId ?? 'not passed';

    this.flightService.findFlight({ id: this.flightId }).subscribe(res => this.flight = res, this.handleError);

  }

  private handleError = (err: any) => {
    if (err.status == 404) {
      alert("Flight not found");
      this.router.navigate(['/search-flights']);
    }
    console.log("Response Error. Status: ", err.status)
    console.log("Response Error. Status Text", err.statusText)
    console.log(err);
  }
}
