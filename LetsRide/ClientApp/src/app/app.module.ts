import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { MatDialog, MatNativeDateModule, MatDialogModule } from '@angular/material';
import { MatFormFieldModule } from '@angular/material/form-field';

import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';

import { AppComponent } from './app.component';

import { DashboardComponent } from './dashboard/dashboard.component';
import { UserProfileComponent } from './user-profile/user-profile.component';


import { TableListComponent } from './table-list/table-list.component';
import { TypographyComponent } from './typography/typography.component';
import { IconsComponent } from './icons/icons.component';
import { MapsComponent } from './maps/maps.component';
import { NotificationsComponent } from './notifications/notifications.component';
import { UpgradeComponent } from './upgrade/upgrade.component';
import { AgmCoreModule} from '@agm/core';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { TripsService } from './services/trips.service';
import { UserService } from './services/user.service';
import { RatingComponent } from './rating/rating.component';

@NgModule({
  imports: [
      BrowserAnimationsModule,
      MatDialogModule,
      FormsModule,
      HttpModule,
      ComponentsModule,
      RouterModule,
      AppRoutingModule,
      BrowserModule,
      FormsModule,
      ReactiveFormsModule,
      MatFormFieldModule,
    
     
      
    AgmCoreModule.forRoot({
      apiKey: 'YOUR_GOOGLE_MAPS_API_KEY'
    })
  ],
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    RatingComponent,

  ],
    providers: [
        TripsService,
        UserService
    ],
    bootstrap: [AppComponent],
    entryComponents: [RatingComponent]
  
})
export class AppModule { }
