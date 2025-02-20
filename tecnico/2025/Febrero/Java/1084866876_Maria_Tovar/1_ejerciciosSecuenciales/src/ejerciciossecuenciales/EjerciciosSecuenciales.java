/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package ejerciciossecuenciales;

import java.util.Scanner;

/**
 *
 * @author USUARIO
 */
public class EjerciciosSecuenciales {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
//        Scanner to read user information.
        Scanner readScanner = new Scanner(System.in);
        
//      Exercise 1: Combersion of temperature        
        System.out.println("Ingresa la temperatura en grados Celsius que quieres combertir: ");
        float temperatureC = readScanner.nextFloat();
        
        float temperatureF = ((9*temperatureC)/5) + 32;
        float temperatureK = temperatureC + 273.15f;
        
        System.out.println("El resultado en grados fahrenheit es:" + temperatureF + " y en kelvin es :" +temperatureK);
        
        
//        Exercise 2: Calculation of the IMC
        System.out.println("Para Calcular su IMC, por favor ingrese su peso en kg: ");
        float weight = readScanner.nextFloat();
        
        System.out.println("Ahora por favor ingresa tu altura en metros: ");
        float height = readScanner.nextFloat();
        
        double imc = weight/(Math.pow(height, 2));
        System.out.println("Su IMC es: "+ imc);     
        
        
//        Exercise 3: Area and perimeter of a triangle
        System.out.println("Para calcular el area y perimetro de un triangulo rectangulo, ingresa la base: ");
        float baseTriangle = readScanner.nextFloat();
        
        System.out.println("Ahora ingresa la altura del triangulo: ");
        float heigthTriangle = readScanner.nextFloat();
        
        float area = baseTriangle * (heigthTriangle/2);
        
        double hypotenuse = Math.sqrt(Math.pow(baseTriangle, 2) + Math.pow(heigthTriangle, 2));
        
        double perimeter = baseTriangle + heigthTriangle + hypotenuse;
        
        System.out.println("El area es: "+area+" y el perimetro es: "+perimeter);
        
        
//        Exercise 4: Operations with two numbers
        System.out.println("Para resalizar diferentes operaciones (+, -, *, /, %), ingresa el numero uno: ");
        float numberOne = readScanner.nextFloat();
        
        System.out.println("Ingresa el número dos: ");
        float numberTwo = readScanner.nextFloat();
        
        float addition = numberOne + numberTwo;
        float subtraction = numberOne - numberTwo;
        float multiplication = numberOne * numberTwo;
        float division = numberOne / numberTwo;
        float modulus = numberOne % numberTwo;
        
        System.out.println("EL resultado de la suma es: "+ addition);
        System.out.println("EL resultado de la resta es: "+ subtraction);
        System.out.println("EL resultado de la multiplicacion es: "+ multiplication);
        System.out.println("EL resultado de la division es: "+ division);
        System.out.println("EL resultado del modulo es: "+ modulus);
        
        
//        Exercise 5: Exchange of values 
        System.out.println("Ingresa el primer numero para intercambiar su valor: ");
        int numOne = readScanner.nextInt();
        
        System.out.println("Ingresa el segundo número: ");
        int numTwo = readScanner.nextInt();
        
        System.out.println("Numeros iniciales: "+ numOne + ", "+ numTwo);
        
        numOne = numOne + numTwo;
        numTwo = numOne - numTwo;
        numOne = numOne - numTwo;
        
        System.out.println("Numeros invertidos: "+ numOne +", "+ numTwo);

    }
    
}
