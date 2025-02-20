/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package ejerciciosciclicos;

import java.util.ArrayList;
import java.util.Scanner;

/**
 *
 * @author USUARIO
 */
public class EjerciciosCiclicos {

    /**
     * @param args the command line arguments
     */
    Scanner readScanner = new Scanner(System.in);

    public static void main(String[] args) {
        // TODO code application logic here
        EjerciciosCiclicos ec = new EjerciciosCiclicos();
        ec.MultiplicationTable();
        ec.AdditionOfNumbers();
        ec.DigitCounter();
        ec.Fibonacci();
        ec.NumberIsPrime();
    }

//    Exercise 1: Multiplication table
    public void MultiplicationTable() {
        System.out.println("Ingresa un numero para mostrar su tabla de multiplicar: ");
        int table = readScanner.nextInt();

        int result = 0;
        int count = 1;
        
        while(count <= 10){
            result = table * count;
            System.out.println(table+ " x " + count + " = " +result);
            count++;
        }
        
    }

//    Exercise 2: Sum of N numbers
    public void AdditionOfNumbers() {
        System.out.println("Ingresa un numero para sumar sus numeros anteriores: ");

        int number = readScanner.nextInt();
        int accumulated = 0;
        int count = 0;
        
        while (count <= number) {            
            accumulated+= count;
            count++;
        }
        System.out.println("La suma de los numeros hasta " + number + " es " + accumulated);

    }

//    Exercise 3: Digit counter
    public void DigitCounter() {
        System.out.println("Ingresa un numero entero para contar sus digitos: ");
        int num = readScanner.nextInt();
        int digitCounter = 0;
        
        do {            
            num = num/10;
            digitCounter++;
        } while (num>0);
        
        System.out.println("El numero tiene " + digitCounter+" digitos.");

    }
    
//    Exercise 4: Fibonacci series
    public void Fibonacci(){
        System.out.println("Ingresa el numero para mostrar su terminos Fibonacci: ");
        int num = readScanner.nextInt();
        
        int fistNumber = 0;
        int secondNumber = 1;
        
        int resultFibonacci = 0;
        
        for (int i = 0; i < num; i++) {
            resultFibonacci = fistNumber + secondNumber;
            System.out.print(resultFibonacci + ", ");
            fistNumber = secondNumber;
            secondNumber = resultFibonacci;
        }

    }
    
//    Exercise 5: Prime numbers in a range
    public void NumberIsPrime(){
        System.out.println("Ingresa un numero para mostrar los numeros primos anteriores: ");
        int limitPrime = readScanner.nextInt();
        
        for (int iteration1 = 2; iteration1 <= limitPrime; iteration1++) {
            boolean numberIsPrime = true;
            for (int iteration2 = 2; iteration2 * iteration2 <= iteration1; iteration2++) {
                if(iteration1 % iteration2 == 0){
                    numberIsPrime = false;
                    break;
                }
            }
            if(numberIsPrime){
                System.out.print(iteration1 + ", ");
            }
        }
       
    }
}
