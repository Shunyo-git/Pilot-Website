	var MenuFlag = false;
	function clock(){
		if( MenuFlag ) HideMenu( true );
	}
	function IniMenu(){
		Toolbar.className = "Toolbar";
		ToolbarBG.className = "Toolbar";
		arrStr = Menus[0].split(",");

		if( MenuDirection == 1 ){
			oTR = Toolbar.rows[0];
			for( i = 1 ; i <= arrStr.length-2 ; i+=2 ){
				oTD = oTR.insertCell(oTR.cells.length);
				oTD.style.behavior = "url(" + HTC_Location + ")";
				oTD.style.padding = "2 6 2 6";
				oTD.name = arrStr[i+1];
				oTD.id = "m00";
				oTD.innerHTML = arrStr[i];
				if( i <= arrStr.length-1 ) oTR = Toolbar.insertRow(Toolbar.rows.length);
			}
		}else{
			if( MenuType == 1 ){
				for( i = 1 ; i <= arrStr.length-2 ; i+=2 ){
					oTD = Toolbar.rows[0].insertCell(Toolbar.rows[0].cells.length);
					oTD.style.behavior = "url(" + HTC_Location + ")";
					oTD.style.padding = "2 6 2 6";
					oTD.name = arrStr[i+1];
					oTD.id = "m00";
					oTD.innerHTML = arrStr[i];
				}
			}else if( MenuType == 2 ){
				for( i = 1 ; i <= arrStr.length-2 ; i+=2 ){
					oTD = Toolbar.rows[0].insertCell(Toolbar.rows[0].cells.length);
					oTD.style.behavior = "url(" + HTC_Location + ")";
					oTD.style.padding = "2 6 2 6";
					oTD.name = arrStr[i+1];
					oTD.id = "m00";
					oTD.innerHTML = arrStr[i];
					oTD = Toolbar.rows[0].insertCell(Toolbar.rows[0].cells.length);
					oTD.width = "3pt";
					oTD.innerText = "|";
					oTD.style.cursor = "default";
					oTD.style.paddingTop = "3pt";
					oTD.style.color = "black";
				}
			}
		}
																								
		for( i = 1 ; i < Menus.length ; i++ ){
			arrStr = Menus[i].split(",");
			oTable = document.createElement("TABLE");
			oTable.cellSpacing = 0;
			oTable.cellPadding = 0;
			oTable.className = "Menu";
			oTable.style.borderCollapce = "collapse";
			oTable.style.display = "none";
			oTable.style.position = "absolute";
			oTable.style.x = 0;
			oTable.style.y = 0;
			oTable.style.zIndex = 3;
			oTable.id = arrStr[0];
			for( j = 1 ; j < arrStr.length ; j+=2 ){
				
				oTR = oTable.insertRow(oTable.rows.length);
				Bid = oTR.addBehavior(HTC_Location);
				oTR.name = arrStr[j+1];
				
				if( arrStr[j] == "#sep" ){
					oTD = oTR.insertCell(0);
					//oTD.style.background = Toolbar.style.background;
					oTD.style.background = "#FFFFFF";
					oTD.style.height = "3pt";
					oTD.innerHTML = "<hr name='MMHr' style='width:95%; height:1px;'>";
					oTD.colSpan = 2;
					oTR.removeBehavior(Bid);
				}else if( arrStr[j].indexOf("#") == 0 ){
					oTD = oTR.insertCell(0);
					oTD.colSpan = 2;
					oTD.innerHTML = arrStr[j].replace("#","");
					oTD.style.paddingLeft = "3pt";
					oTD.style.paddingRight = AdjustWidth + "pt";
					//oTD.align = "center";
					oTD.disabled = true;
				}else if( arrStr[j].indexOf("@") == 0 ){
					oTD = oTR.insertCell(0);
					oTD.colSpan = 2;
					tempStr = arrStr[j].replace("#","");
					oTD.innerHTML = tempStr.substring(1,tempStr.length);
					oTD.style.paddingLeft = "3pt";
					oTD.style.paddingRight = AdjustWidth + "pt";
					oTD.style.fontWeight = "bold";
					oTD.className = "MenuOFF";
					oTR.removeBehavior(Bid);
				}else{
					oTD = oTR.insertCell(0);
					oTD.innerHTML = arrStr[j];
					oTD.style.paddingLeft = "3pt";
					oTD.style.paddingRight = AdjustWidth + "pt";
					Flag = oTR.name.indexOf("#m") != -1;
					oTD = oTR.insertCell(1);
					oTD.style.width = "18px";
					oTD.align = "center";
					if( Flag ){
						oTD.innerHTML = "<font face='webdings' style='font-size:10pt;'>4</font>";
						//oTD.detachEvent("onmouseover",);
						oTD.removeBehavior(Bid);
					}else{
						oTD.innerHTML = "&nbsp;";
					}
					
				}
			}
			document.body.appendChild(oTable);
		}
	}
	var ActiveMenu = null;
	var ActiveItem = null;
	var MenuQueue = "";
	function ShowMenu( objStr, objSource, Left, Top ){
		objSel = document.getElementsByTagName("SELECT");
		if( objSel!= null ) for( i = 0 ; i < objSel.length ; i++ ) objSel[i].style.visibility = "hidden";
		TarObj = document.all(objStr);
		if( objSource == "m00" ){
			TempArr = MenuQueue.split( "," );
			for( i = 0 ; i < TempArr.length-1 ; i++ ){
				document.all(TempArr[i]).style.display = "none";
			}
			MenuQueue = "";
		}
		if( ActiveMenu != null ){
			if( ActiveMenu != document.all(objSource) ){
				ActiveMenu.style.display = "none";
				MenuQueue.replace( ActiveMenu.id + ",", "" );
			}
		}
		if( TarObj != null ){
			TarObj.style.display = "inline";
			TempArr = MenuQueue.split( "," );
			if( MenuQueue.indexOf( objStr + "," ) == -1 )  MenuQueue += objStr + ","
			TarObj.style.left = Left;
			TarObj.style.top = Top;
			ActiveMenu = document.all(objStr);
		}
	}
	function HideMenu( Flag ){
		objSel = document.getElementsByTagName("SELECT");
		if( objSel!= null ) for( i = 0 ; i < objSel.length ; i++ ) objSel[i].style.visibility = "visible";
		//Flag為關閉選單的參數，true為強迫關閉，false為判斷關閉
		if( !Flag ){
			if( event.srcElement.tagName != "TR" && event.srcElement.tagName != "TD" ){
				Flag = true;
				if( event.srcElement.tagName == "IMG" && event.srcElement.src.indexOf("images/arrow.gif") != -1 ){
					Flag = false;
				}
				if( event.srcElement.tagName == "HR" && event.srcElement.name == "MMHr" ){
					Flag = false;
				}
			}else{
				TarObj = event.srcElement.parentElement;
				while( TarObj.tagName != "TABLE" ) TarObj = TarObj.parentElement;
				if( TarObj.id.indexOf("m") != 0 ) Flag = true;
			}
		}
		if( Flag ){
			TempArr = MenuQueue.split( "," );
			for( i = 0 ; i < TempArr.length-1 ; i++ ){
				document.all(TempArr[i]).style.display = "none";
			}
			MenuQueue = "";
			if( ActiveItem != null ) ActiveItem.className = "ItemOFF";
		}
	}