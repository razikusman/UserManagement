import { Action, createAction, props } from '@ngrx/store';

export enum userActionTypes{
    LOGIN= 'LOGIN'
}

export class Login implements Action{
    readonly type =userActionTypes.LOGIN
    
    constructor(public payload:boolean) { }
}

export type CartActions = Login;
// export const decrement = createAction('[Counter] Decrement');
// export const reset = createAction('[Counter] Reset');