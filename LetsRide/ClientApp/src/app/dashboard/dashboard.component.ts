import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { config } from 'rxjs';
@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

    isLinear = false;
    firstFormGroup: FormGroup;
    secondFormGroup: FormGroup;
    test: Date = new Date();
    focus;
    focus1;

    constructor() { }

    ngOnInit() {

    }
    TripsForm = new FormGroup({
        fromDestination: new FormControl('', Validators.required),
        toDestination: new FormControl('', Validators.required),
        StartTime: new FormControl(new Date(), Validators.required),
        ExpectedArrivalTime: new FormControl(new Date()),
        Details: new FormControl(''),
        CarInfo: new FormControl('', Validators.required),
        Price: new FormControl(),
        seatsNo: new FormControl('', Validators.required),
        carNo: new FormControl('', Validators.required)
    })

    get fromDestination() {
        return this.TripsForm.get('fromDestination') as FormControl
    }
    get toDestination() {
        return this.TripsForm.get('toDestination') as FormControl
    }
    get StartTime() {
        return this.TripsForm.get('StartTime') as FormControl
    }
    get ExpectedArrivalTime() {
        return this.TripsForm.get('ExpectedArrivalTime') as FormControl
    }
    get Details() {
        return this.TripsForm.get('Details') as FormControl
    }
    get Price() {
        return this.TripsForm.get('Price') as FormControl
    }
    get CarInfo() {
        return this.TripsForm.get('CarInfo') as FormControl
    }
    get seatsNo() {
        return this.TripsForm.get('seatsNo') as FormControl
    }
    get carNo() {
        return this.TripsForm.get('carNo') as FormControl
    }

    submitTrip() {

    }

    changeDate() {
        console.log("angular")
        console.log(this.TripsForm)
    }

}
