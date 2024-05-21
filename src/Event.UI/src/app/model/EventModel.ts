export class EventModel{
public name! : string;// { get; private set; }
public description? : string;//  { get; private set; }
public type! : number;// { get; private set; }
public address! : string;// { get; private set; }
public city? : string; //{ get; private set; }
public region? : string; // { get; private set; }
public postalCode? : string; // { get; private set; }
public country? : string; // { get; private set; }
public phone! : string;//{ get; private set; }
public startDate! : Date // { get; private set; }
public endDate! : Date;  //{ get; private set; }
public isComplete : boolean = false; // { get; private set; }
public userId? : string ;  //{ get; private set; }
}