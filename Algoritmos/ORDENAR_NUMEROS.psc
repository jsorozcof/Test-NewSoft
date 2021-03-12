//FABER OROZCO
Algoritmo ORDENAR_NUMEROS
	definir n,x,n1,n2,n3 como entero
	Escribir "ingrese 3 numeros *OJO solo enteros"
	Para x = 1 Hasta 3 Con Paso 1 Hacer
		Leer n
		Si x == 1 Entonces
			n1 = n
		FinSi
		Si x == 2 Entonces
			Si n1 > n Entonces
				n2 = n1
				n1 = n
			SiNo
				n2 = n
			FinSi
		FinSi
		Si x == 3 Entonces
			Si n1 > n Entonces
				n3 = n2
				n2 = n1
				n1 = n
			SiNo
				Si n2 > n Entonces
					n3 = n2
					n2 = n
				SiNo
					n3 = n
				FinSi
			FinSi
		FinSi
		
	FinPara
	Escribir n3
	Escribir n2
	Escribir n1
FinAlgoritmo
