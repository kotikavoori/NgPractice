import { Component, AfterViewInit } from '@angular/core';
import { Subscription } from '../../node_modules/rxjs';
import { Helpers } from './helpers/Helpers';
import { startWith, delay } from '../../node_modules/rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit {
  title = 'app';
sunbscription: Subscription;
authentication: boolean;

/**
 *
 */
constructor(private helpers: Helpers ) {
}
ngAfterViewInit() {
this.sunbscription = this.helpers.isAuthenticationChanged().pipe(
startWith(this.helpers.isAuthenticated() ) ,
delay(0)).subscribe((value) =>
this.authentication = value
);
}
ngOnDestroy() {
this.sunbscription.unsubscribe();
}


}
