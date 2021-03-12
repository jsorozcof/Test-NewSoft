Algoritmo PROMEDIODIAGONAL
	Dimension m[50,50]
	Dimension vd[5]
		//Desarrollo de la matriz//
		Escribir "Ingrese la cantidad de filas y clumnas de la matriz";
		Escribir "N°. de filas:"
		Leer a
		Escribir "N°. de columnas:"
		Leer b
		Si a=b Entonces
			Escribir "Ingrese datos de la matriz"
			//Llenar la matriz//
			Escribir ""
			Para I<-1 Hasta A Con Paso 1 Hacer
				Para J<-1 Hasta B Con Paso 1 Hacer
					Escribir "Ingrese dato de la posicion",i,",",j
					Leer m[i,j]
					//Grabamos la diagonal en el vector//
					si J=I Entonces
						vd[i]=m[i,j]
					fin si
				FinPara
			FinPara
			//Imprimir matriz//
			Para J<-1 Hasta a Con Paso 1 Hacer
				Para I<-1 Hasta b Con Paso 1 Hacer
					Escribir m[i,j]," " Sin Saltar
				FinPara
				escribir ""
			FinPara
			Escribir ""
			Escribir "Los elementos almacenados en en el vector son :"
			Para I<-1 Hasta A Hacer
				Escribir vd[I]
			FinPara
		Sino
			Escribir " error"
			Escribir " La matriz no es proporcianal"
			Escribir " Presione una tecla para contienuar"
		FinSi
FinAlgoritmo
