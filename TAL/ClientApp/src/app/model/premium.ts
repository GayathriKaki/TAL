export interface IMember {
    name: string;
    age: Number;
  occupationId: Number;
  stateId: Number;
    dateOfBirth: Date;
    deathSumInsured: Number;
    premium: Number;  
  monthlyexpenses: Number;
}

 

export interface IOccupation{
    occupationId: Number;
  occupationName: string;
  ratingId: Number;
}

export interface IStates {
  stateId: Number;
  stateName: string;

}
//export interface IPremium {
//    name: string;
//    age: Number;
//    occupationId: Number;
//    dateOfBirth: Date;
//    deathSumInsured: Number;
//    premium: Number;
//}
