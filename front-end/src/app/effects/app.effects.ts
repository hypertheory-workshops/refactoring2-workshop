import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map } from 'rxjs';
import * as authActions from '../actions/auth.actions';
@Injectable()
export class AppEffects {
  logOut$ = createEffect(
    () => {
      return this.actions$.pipe(
        ofType(authActions.logOut),
        map(() => this.router.navigate(['home'])),
      );
    },
    { dispatch: false },
  );

  constructor(private actions$: Actions, private router: Router) {}
}
