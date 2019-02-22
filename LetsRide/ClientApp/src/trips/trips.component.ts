import { Component, OnInit } from '@angular/core';
import { TripsService } from 'app/services/trips.service';

@Component({
    selector: 'app-trips',
    templateUrl: './trips.component.html',
    styleUrls: ['./trips.component.scss']
})
/** trips component*/
export class TripsComponent implements OnInit {

    public allTrips: Array<any> = []; 
    /** trips ctor */
    constructor(private tripsService : TripsService) {
    }

    ngOnInit() {
        this.tripsService.getAllTrips().subscribe(response => {
        })
    }
}