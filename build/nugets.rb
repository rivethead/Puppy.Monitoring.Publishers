@nugets = [
	{
		:package_id => 'Puppy.Monitoring.DucksboardPublisher',
		:description => 'Puppy.Monitoring.DucksboardPublisher',
		:authors => 'rivethead_',
		:base_folder => 'Puppy.Monitoring.DucksboardPublisher/',
		:files => [
			['Puppy.Monitoring.DucksboardPublisher.dll', 'lib\net45'],
			['Puppy.Monitoring.DucksboardPublisher.pdb', 'lib\net45'],
		],
		:dependencies => [
			['Common.Logging', '(2.1.1,2.12)'],
			['Puppy.Monitoring', ''],
		]
	},
	{
		:package_id => 'Puppy.Monitoring.SqlServerPublisher',
		:description => 'Puppy.Monitoring.SqlServerPublisher',
		:authors => 'rivethead_',
		:base_folder => 'Puppy.Monitoring.SqlServerPublisher/',
		:files => [
			['Puppy.Monitoring.SqlServerPublisher.dll', 'lib\net45'],
			['Puppy.Monitoring.SqlServerPublisher.pdb', 'lib\net45']
		],
		:dependencies => [
			['FluentMigrator', '1.0.6.0'],
			['FluentMigrator.Tools', '1.0.6.0'],
			['Common.Logging', '(2.1.1,2.12)'],
			['Puppy.Monitoring', ''],
		]
	}
]