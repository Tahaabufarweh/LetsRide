import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
/** Login component*/
export class LoginComponent {
    loginForm = new FormGroup({
        username: new FormControl('', Validators.required),
        password: new FormControl('', Validators.required)
    })

    constructor() { }


    ngOnInit() { }

    get username() {
        return this.loginForm.get('username') as FormControl;
    }

    get password() {
        return this.loginForm.get('password') as FormControl;
    }



    login() {}
        

}