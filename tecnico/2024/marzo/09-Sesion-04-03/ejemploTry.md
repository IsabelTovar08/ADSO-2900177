# Cuando se usa Try-Except

En Python existe una instrucción que nos permite capturar los errores y manejarlos según nuestra necesidad. Para capturar errores, usamos las instrucciones try y except. Dentro del bloque try, encontraremos el código que debe ejecutarse para completar nuestro programa, mientras que en el bloque except encontramos las instrucciones que se ejecutan cuando algo dentro del bloque try falla. 

## Ejemplo
Sumar dos números
```python
msgError="Eror, por favor, ingrese un número válido."
def suma():
    try:
        n1 = float(input("Para realizar la suma, ingrese el primer número: "))
        n2 = float(input("Para realizar la suma, ingrese el segundo número: "))

        resultado = n1 + n2

        print(f"La suma de",n1,"+",n2,"es: {resultado}")

    except ValueError:
        print("msgError")

if __name__ == "__main__":
    suma()

```