//FABER OROZCO
Algoritmo VECTOR_NUMERO_MAYOR
		Escribir "Ingrese la cantidad de filas y columnas del vector";
		Escribir "N°. Filas:"
		Leer a
		Escribir "N°. Columnas:"
		Leer b
		Dimension m[100,100] // RANGO
		valorMayor<-0
		Escribir "Ingrese datos del vector"
		Para i<-1 Hasta A Con Paso 1 Hacer
			Para j<-1 Hasta b Con Paso 1 Hacer
				Escribir "Ingrese datos de la posicion",i,",",j
				Leer m[i,j]
				Si m[i,j]>valorMayor Entonces
					valorMayor<-m[i,j]
				FinSi
			FinPara
		FinPara
		Escribir ""
		Para i<-1 Hasta A Con Paso 1 Hacer
			Para j<-1 Hasta b Con Paso 1 Hacer
				Escribir m[i,j]," " Sin Saltar
			FinPara
			Escribir ""
		FinPara
		Escribir ""
		Escribir "El valor mayor del vector es :",valorMayor

FinAlgoritmo
