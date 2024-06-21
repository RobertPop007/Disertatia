import { Component, Input, OnInit, Output, EventEmitter, NgZone } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

declare const FB: any;

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @Output() cancelRegister = new EventEmitter();
  registerForm!: FormGroup;
  validationErrors: string[] = [];
  emailPattern: any = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";

  constructor(private accountService: AccountService,
              private toastr: ToastrService,
              private fb: FormBuilder,
              private _ngZone: NgZone,
              private router: Router) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(){
    this.registerForm = this.fb.group({
      username: ['', Validators.required],
      gender: ['Male'],
      knownAs: ['', Validators.required],
      email: ['', [Validators.required, Validators.pattern(this.emailPattern)]],
      dateOfBirth: ['', Validators.required],
      city: ['', Validators.required],
      country: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(100), Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{6,}') ]],
      confirmPassword: ['', [Validators.required, this.matchValues('password')]]
    })
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      const controls = control?.parent?.controls as { [key: string]: AbstractControl; };
      let matchToControl = null;    
      if(controls) matchToControl = controls[matchTo];       
      return control?.value === matchToControl?.value
        ? null : { isMatching: true }
    }
  }

  register(){
    this.accountService.register(this.registerForm.value).subscribe(response =>{
      //this.router.navigateByUrl('/home');
      
      this.registerForm.reset();
      this.logout();
      this.toastr.success("Your account has been created, please confirm your email before log in!");
    }, error => {
      this.validationErrors = error;
    })
  }

  goToSignIn(){
    window.location.reload();
  }

  cancel(){
    this.cancelRegister.emit(false);
  }

  logout(){
    this.accountService.logout();
    //this.goToSignIn();
  }

  async login(){
    FB.login(async (result:any) => {
      console.log(result)
      this.accountService.LoginWithFacebook(result.authResponse.accessToken).subscribe(
        (x:any) => {
          this._ngZone.run(() => {
            this.router.navigate(['logout']);
          })
        },
        (error:any) => {
          console.log(error);
        }
      );
    }, {scope : 'email'});
  }
}
