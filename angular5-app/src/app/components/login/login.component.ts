import { Component, OnInit } from '@angular/core';
import { Helpers } from '../../helpers/Helpers';
import { TokenService } from '../../services/token.service';
import { Router } from '../../../../node_modules/@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router: Router, private helpers: Helpers, private tokenService: TokenService ) { }

  ngOnInit() {
  }

login(): void {

  const authValues = { 'UserName' : 'pablo', 'Password': 'secrets'};

this.tokenService.auth(authValues).subscribe(token => {
this.helpers.setToken(token);
this.router.navigate(['/dashboard']);

} );

}

}
