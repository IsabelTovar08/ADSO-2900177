/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package ejercicioscondicionales;

import java.util.Scanner;

/**
 *
 * @author USUARIO
 */
public class EjerciciosCondicionales {

    Scanner readScanner = new Scanner(System.in);

    public static void main(String[] args) {
        EjerciciosCondicionales ec = new EjerciciosCondicionales();
        ec.NumberIsPositive();
        ec.ThreeNumbers();
        ec.LeapYear();
        ec.SimpleCalculator();
        ec.ClassificationOfTriangles();
    }

//  Exercise 1: Number positive, negative or zero
    public void NumberIsPositive() {
        System.out.println("Ingresa un numero para saber si es positivo, negativo o zero: ");
        int number = readScanner.nextInt();

        if (number != 0) {
            if (number > 0) {
                System.out.println("El numero ingreasado es positivo, mayor a cero.");
            } else {
                System.out.println("El numero ingresado es negativo, menor a cero.");
            }
        } else {
            System.out.println("EL numero ingresado es cero.");
        }

    }

// Exercise 2: Greater than three numbers
    public void ThreeNumbers() {

        System.out.println("Para comparar tres numeros, ingresa el primer numero: ");
        int numberOne = readScanner.nextInt();

        System.out.println("Ingresa el segundo número: ");
        int numberTwo = readScanner.nextInt();

        System.out.println("Ingresa el tercer número: ");
        int numberThree = readScanner.nextInt();
        int mayor;

        if (numberOne == numberTwo && numberTwo == numberThree && numberOne == numberThree) {
            System.out.println("Todos los numeros son iguales.");

        } else {
            if (numberOne >= numberTwo && numberOne >= numberThree) {
                System.out.println("El numero mayor es: " + numberOne);
            } else if (numberTwo >= numberOne && numberTwo >= numberThree) {
                System.out.println("El numero mayor es: " + numberTwo);
            } else if (numberThree >= numberOne && numberThree >= numberTwo) {
                System.out.println("El numero mayor es: " + numberThree);
            }
        }
        if (numberOne == numberTwo && numberOne != numberThree) {
            System.out.println("EL primer y segundo numero son iguales.");
        } else if (numberTwo == numberThree && numberOne != numberTwo) {
            System.out.println("El segundo y tercer numero son iguales.");
        } else if (numberOne == numberThree && numberOne != numberTwo) {
            System.out.println("El primer y tercer numero son iguales.");
        }

    }

//    Exercise 3: Leap Year
    public void LeapYear() {
        Scanner readScanner = new Scanner(System.in);

        System.out.println("Ingresa un año para saber si es bisiesto o no: ");
        int year = readScanner.nextInt();

        if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) {
            System.out.println("El año " + year + " es bisiesto.");

        } else {
            System.out.println("El año " + year + " no es bisiesto.");
        }

    }

//    Exercise 4: Simple Calculator
    public void SimpleCalculator() {
        System.out.print("Para realizar un calculo, ingresa el primer número: ");
        float n1 = readScanner.nextFloat();

        System.out.print("Ingresa el segundo número: ");
        float n2 = readScanner.nextFloat();

        System.out.println("Ingresa el operador: (+, -, *, /)");
        char operator = readScanner.next().charAt(0);
        float result;

        switch (operator) {
            case '+':
                result = n1 + n2;
                System.out.println("EL resultado de la suma(+) es: " + result);
                break;
            case '-':
                result = n1 - n2;
                System.out.println("EL resultado de la resta(-) es: " + result);

                break;
            case '*':
                result = n1 * n2;
                System.out.println("EL resultado de la multiplicacion(*) es: " + result);

                break;
            case '/':
                result = n1 / n2;
                System.out.println("EL resultado de la division(/) es: " + result);

                break;
            default:
                System.out.println("Simbolo no reconocido.");
        }

    }

//    Exercise 5: Classification of triangles
    public void ClassificationOfTriangles() {
        System.out.println("Para clasificar un triangulo, ingresa las medidas del primer lado: ");
        float sideOne = readScanner.nextFloat();

        System.out.println("Ingresa las medidas del segundo lado: ");
        float sideTwo = readScanner.nextFloat();

        System.out.println("Ingresa las medidas del tercer lado: ");
        float sideThree = readScanner.nextFloat();

        if (sideOne == sideTwo && sideTwo == sideThree && sideOne == sideThree) {
            System.out.println("Todos los lados son iguales, es un triangulo equilatero.");
        } else if (sideOne == sideTwo || sideOne == sideThree || sideTwo == sideThree) {
            System.out.println("Tiene dos lados iguales, es un triangulo isosceles");
        } else {
            System.out.println("Todos sus lados son diferentes, es un triangulo escaleno.");
        }

    }

}
