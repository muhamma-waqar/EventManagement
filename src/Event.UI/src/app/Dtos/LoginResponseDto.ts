export class LoginResponseDto{

    public accessToken! : string ;
    public tokenType : string = 'Bearer';
    public expiresIn! : number;
    public userName! : string;
    public email! : String; 
    public externalAuthenticationProvider? : string
    public IsExternalLogin : boolean = ! undefined;
}