import { Component, OnInit } from '@angular/core';
import { FlightRm } from '../api/models';
import { FlightService } from '../api/services';

@Component({
  selector: 'app-search-flighs',
  templateUrl: './search-flighs.component.html',
  styleUrls: ['./search-flighs.component.css']
})
export class SearchFlighsComponent implements OnInit {
  searchResult: FlightRm[] = [];
  constructor(private flightService : FlightService) { }

  ngOnInit(): void {
  }

  search() {
    this.flightService.searchFlight({}).subscribe(response => this.searchResult = response, this.handleError)
  }

  private handleError(err: any) {
    console.log("Response Error. Status: ", err.status)
    console.log("Response Error. Status Text", err.statusText)
    console.log(err);
  }
}
