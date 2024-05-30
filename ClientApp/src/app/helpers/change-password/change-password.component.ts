import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ResetPasswordModel } from 'model/resetPasswordModel';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss'],
  providers: [
    AccountService
  ]
})
export class ChangePasswordComponent implements OnInit {

  email!: string;
  token!: string;
  encodedToken!: string;
  resetPasswordModel: ResetPasswordModel = {} as ResetPasswordModel;
  password: string = '';
  confirmPassword: string = '';
  registerForm!: FormGroup;
  validationErrors: string[] = [];

  constructor(private route: ActivatedRoute,
    private accountService: AccountService,
    private toastr: ToastrService,
    private router: Router,
    private fb: FormBuilder) { 
      this.route.queryParams.subscribe(params => {
        this.email = params['email'];
        this.token = params['token'];
  
        this.encodedToken = encodeURIComponent(this.token);
      });
    }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(){
    this.registerForm = this.fb.group({
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

  onChangePassword(){
    this.resetPasswordModel.password = this.registerForm.get('password')?.value;
    this.resetPasswordModel.confirmPassword = this.registerForm.get('confirmPassword')?.value;
    this.resetPasswordModel.token = this.token;
    this.resetPasswordModel.email = this.email;
    console.log(this.resetPasswordModel)
    this.accountService.resetPassword(this.resetPasswordModel).subscribe(() => {
      this.toastr.success("Your passowrd has been changed successfully, please logout and try it!")
      this.resetForm();
    },
  () => this.toastr.error("Something went wrong"));
  }

  logout(){
    this.accountService.logout();
    this.goToSignIn();
  }

  resetForm(){
    this.registerForm.controls['password'].setValue('');
    this.registerForm.controls['confirmPassword'].setValue('');
  }

  goToSignIn(){
    window.location.reload();
  }
}
