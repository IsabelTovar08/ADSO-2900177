# LISTAS 
lista = [1,2,3,4,5,6,7,8,9,10]
print(sum(lista)/len(lista))
lista_par = lista[1::2]
print(lista_par)

def existe(num):
    if(num in lista):
        indexR = lista.index(num)
        return print("El index de "+ str(num) +" es "+ str(indexR)) 
    
existe(8)

# TUPLAS 
tupla = (1,2,3,4,5,"Hola", "Isabel", 1.2)
print(tupla)
print(tupla.count(3))
tupla_dos = ("a", "b", "c")
uno, dos, tres = tupla_dos
print(uno, dos, tres)
listaTupla = list(tupla)
listaTupla.extend(["e", "f"])
print(listaTupla)
tuplaNums = (1,2,3,4,5)
numsDos = (6,7,8)
print(sum(tuplaNums))
result = tuplaNums + numsDos
print(result * 3)

# STRINGS 
cadena = "Hola, bnos días"
# def contar(cadenas):
#     vocal =0
#     for 'a' or 'e' or 'i' or 'o' or 'u' in cadenas:
#         # return print("La cadena contiene "+str(vocales)+" vocales")
#         vocal+=1
#         print("La cadena contiene vocales "+ str(vocal))
#     else:
#         return print("La cadena no contiene vocales")

# contar(cadena)
print(cadena.upper())
print(cadena.lower())

# SETS 
listaSet = [2,2,3,3,1]
setu = set(listaSet)
print(setu)
setDos = set([1,4,5])
print(setDos)
print(setu & setDos)

setCadena = set(cadena)
print(setCadena)

# DICCIONARIOS 
diccionario = {"nombre": "Isabel", "edad": 25, "ciudad": "Neiva"}

def exisClave(clave):
    if clave in diccionario:
        print("si existe")
    else:
        print("no existe")

exisClave("apellido ")
