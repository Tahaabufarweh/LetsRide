import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';
import { RatingComponent } from '../rating/rating.component';


@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
    fileNameDialogRef: MatDialogRef<RatingComponent>;
    constructor(public dialog: MatDialog) { }

    openDialog() {
        this.fileNameDialogRef = this.dialog.open(RatingComponent);


    }
  ngOnInit() {
  }

}



