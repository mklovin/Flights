import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { PassengerService } from './../api/services/passenger.service';
@Component({
  selector: 'app-register-passenger',
  templateUrl: './register-passenger.component.html',
  styleUrls: ['./register-passenger.component.css']
})
export class RegisterPassengerComponent implements OnInit {

  constructor(
    private passengerService: PassengerService,
    private formBuilder: FormBuilder
  ) { }

  form = this.formBuilder.group({
    email: [''],
    firstName: [''],
    lastName: [''],
    isFemail: [true],
  })

  ngOnInit(): void {
  }


  register() {

    this.passengerService.registerPassenger({ body: this.form.value }).subscribe(_ => console.log("from posted to server "));

  }
}
