import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginResponseDto } from '../../../dtos/loginResponseDto';
import { LoginService } from '../../../services/login.service';
import { LocalStoratesService } from '../../../services/local-storates.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit{
  loginForm: FormGroup;
  private loginResponse = new LoginResponseDto
    constructor(private fb: FormBuilder, 
      private loginService : LoginService , 
      private router : Router,
      private localStorage : LocalStoratesService){
      this.loginForm = fb.group({
        email:['',[Validators.required, Validators.email]],
        password:['',[Validators.required]]
      })
    }
  
    ngOnInit(): void {
      console.log(this.loginResponse.accessToken);
    }
  
    onSubmit(){
      if(this.loginForm.valid){
        var {email,password} = this.loginForm.value
        this.loginService.login(email,password).subscribe(
          (response) =>{
          this.loginResponse = response
          console.log(response)
          let token = response.accessToken.replace(/^"|"$/g, '');
          this.localStorage.setItem('token',token);
          this.router.navigateByUrl('home')
        },
        (error) =>{
          console.log('login failed',error);
          this.router.navigateByUrl('home')
        })
      }
    }
}
