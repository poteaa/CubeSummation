public function post_confirm() {
	
	$driverId = Input::get('driver_id');
	$servicioId = Input::get('service_id');	
	$servicio = Service::find($servicioId);
	$error = '0';
	
	if($servicio != NULL) {
		if($servicio->status_id == '6') {
			$error = '2';
		}
		else if($servicio->driver_id == NULL && $servicio->status_id == '1') {
			$servicio = Service::update($servicioId, array(
						'driver_id' => $driverId,
						'status_id' => '2'
			));
			Driver::update($driverId, array(
				"available" => '0'
			));
			$driverTmp = Driver::find($driverId);
			Service::update($servicioId, array(
				'car_id' => $driverTmp->car_id
			));
			// Notifica al usuario
			$pushMessage = 'Tu servicio ha sido confirmado!';
			$servicio = Service::find($servicioId);
			$pushMessage = Push::make();
			if($servicio->user->uuid != '') {
				if($servicio->user->type == '1') { // iPhone
					$result = $push->ios($servicio->user->uuid, $pushMessage, 1, 'honk.wav', 'Open', array('serviceId' => servicio->id));				
				} else { // android
					$result = $push->android2($servicio->user->uuid, $pushMessage, 1, 'default', 'Open', array('serviceId' => servicio->id));
				}
			}
		} else {
			$error = '1';
		}
	} else {
		$error = '3';
	}
	
	return Response::json(array('error' => $error));
}