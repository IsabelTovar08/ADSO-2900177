import random

def palabra_aleatoria():
    palabras = ["perro", "gato", "elefante", "leon"]
    aleatoria= random.choice(palabras)
    return aleatoria

def mostar_tablero(palabra_adivinar,letras_adivinadas):
    tablero=""
    for letra in palabra_adivinar:
        if letra in letras_adivinadas:
            tablero+=letra
        else:
            tablero+="_"
    print(tablero)

def jugar():
    palabra_adivinar=palabra_aleatoria()
    letras_adivinadas=[]
    intentos=6

    while intentos>0:
        mostar_tablero(palabra_adivinar,letras_adivinadas)
        letra=input("Ingrese una letra: ").lower()

        if letra in letras_adivinadas:
            print("Ya ingresaste esa letra, prueba con otra")
            continue

        if letra in palabra_adivinar:
            letras_adivinadas.append(letra)
            if set(letras_adivinadas) == set(palabra_adivinar):
                print("Felicidades, adivinaste la palabra")
                break
        else:
            intentos-=1
            print("Letra Incorrecta, te quedan",intentos,"intentos.")
    if intentos==0:
        print("Lo siento, no adivinaste la palabra. La palabra era",palabra_adivinar)
jugar()