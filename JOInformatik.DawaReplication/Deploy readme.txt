Deploy instructions
-------------------

- Copy folder to destination server
- Rename folder to 'DawaReplication'
- Create subfolder 'Logs' in folder DawaReplication
- Edit config file (for PROD):
    Set connectionString to '?'
	UdtraekRowsMax = 0
	TableInfoFile = 'ProdTableInfoList.csv'
	EntityProcessMode = 'Update'
	WaitForUserInput = false
