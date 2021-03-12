//Faber Orozco
Algoritmo PRODUCTOENTREDOSNUMEROS
	producto <- 0
	Escribir "Ingrese el valor del primer numero: ";
	Leer n1;
	
	Escribir "Ingrese el valor del segundo numero: ";
	Leer n2;
	
	
	Mientras n2 <> 0 // equivale a n2 <> 0
		producto <- producto + n1 // Realiza la suma de n veces el valor  del mismo numero (multiplicando) tantas veces como indica otro número
		n2 <- n2 - 1
	FinMientras
	
	Escribir  "El producto de los numeros es : ", producto
FinAlgoritmo
