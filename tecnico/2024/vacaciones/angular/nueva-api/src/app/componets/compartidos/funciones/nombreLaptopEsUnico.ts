import { inject } from "@angular/core";
import { AbstractControl, AsyncValidatorFn, ValidationErrors } from "@angular/forms";
import { LaptopService } from "../../../services/laptop.service";
import { catchError, map, Observable, of } from "rxjs";
import { ActivatedRoute } from "@angular/router";

export function nombreLaptopUnico() :AsyncValidatorFn{
    const laptopService = inject(LaptopService);
    const activatedRoute = inject(ActivatedRoute);

    return (control: AbstractControl): Observable<ValidationErrors | null> => {
        if(control.pristine || !control.value){
            return of(null);
        }

        const id = activatedRoute.snapshot.paramMap.get('id') ?? "0";

        return laptopService.ExistePorNombre(control.value, id).pipe(
            map((existe) => (existe ? {mensaje: "Ya existe una Laptop con este nombre"} : null)),
            catchError(() => of(null))
        )
    }

}