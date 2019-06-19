
<?php 
	
	// Datos Conexión Base de Datos  
	
		$servidorBaseDatos = 'localhost'; 
		
		$usuarioBaseDatos = 'root'; 
		$contrasenaBaseDatos = ''; 
		
		$baseDatos = 'guiar_bd'; 
	
	// Datos Login 
	
		$login_nombreUsuario = $_GET['login_nombreUsuario']; 
		$login_contrasena = $_GET['login_contrasena']; 
	
	// Conexion Base de Datos e Ingreso 
		
		//$conexion = new mysqli($servidorBaseDatos, $usuarioBaseDatos, $contrasenaBaseDatos, $baseDatos); 
		$conexion = mysqli_connect($servidorBaseDatos, $usuarioBaseDatos, $contrasenaBaseDatos, $baseDatos); 
		
		if(!$conexion) { 
				echo "- ✘ Conexión a Base de Datos: Fallado! "."</br>"; 
				echo "- ...... Error: No se pudo conectar a MySQL.".PHP_EOL ."</br>"; 
				echo "- ...... Errno de depuración: ".mysqli_connect_errno().PHP_EOL ."</br>"; 
				echo "- ...... Error de depuración: ".mysqli_connect_error().PHP_EOL ."</br>"; 
				exit();
			} 
		else { 
				echo "- ✔ Conexión a Base de Datos: Logrado! ".PHP_EOL ."</br>"; 
				echo "- ...... Información del Host: ".mysqli_get_host_info($conexion).PHP_EOL ."</br></br>"; 
				
				// Consulta de Usuario 
				
		$tablaResultado = mysqli_query($conexion, "SELECT `codigo` FROM `usuario` WHERE `nombreUsuario`='$login_nombreUsuario' "); 
				
				$filaTablaResultado = mysqli_fetch_array($tablaResultado);
				if($filaTablaResultado['codigo']=="") { 
						echo "-- ✘ No Existen Usuarios '".$login_nombreUsuario."'."."</br>"; 
					} 
				else { 
						echo "-- ✔ Se encontró '".mysqli_num_rows($tablaResultado)."' Usuario(s) '".$login_nombreUsuario."'."."</br>"; 
						echo "--- ✔ Código de Primer Usuario Encontrado: ".$filaTablaResultado['codigo']."</br>"; 
						
						// Validación de Contraseña
						
						$login_codigo = $filaTablaResultado['codigo']; 
						$tablaResultado = mysqli_query($conexion, "SELECT `codigo`, `nombreUsuario`, `tipo`, `nombre`, `apellido` FROM `usuario` WHERE `codigo`='$login_codigo' AND `contrasena` = '$login_contrasena' "); 
				
						$filaTablaResultado = mysqli_fetch_array($tablaResultado);
						if($filaTablaResultado['nombreUsuario']!=$login_nombreUsuario) { 
								echo "--- ✘ Contraseña Incorrecta"."</br>"; 
							} 
						else { 
								echo "--- ✔ Contraseña Correcta"."</br>"; 
								echo "--- ...... Bienvenido '".$filaTablaResultado['nombre']." ".$filaTablaResultado['apellido']."'. </br>"; 
							} 
						
					} 
					
			} 
			
		mysqli_close($conexion); 
		echo "</br>- ✔ Conexión a Base de Datos: Terminado! "; 
		
?> 
