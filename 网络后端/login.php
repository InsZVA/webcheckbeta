<?php
//Configures
	include("antiinject.php");	//反SQL注入
	$bbs="Discuz_";				//论坛前缀
	$pre="pre_";				//表前缀
	$sqlusername="root";		//MySQL用户名
	$sqlpwd="password";			//MySQL密码

	$con=mysqli_connect("localhost",$sqlusername,$sqlpwd);
	if (!$con)
  	{
  		die('Could not connect: ' . mysql_error());
  	}
	mysqli_select_db($con,$bbs."bbs");
	$result = mysqli_query($con,"SELECT * FROM ".$pre."_ucenter_members WHERE username = \"" . $_POST['user'] . "\"");
	if(!$result){echo "0";exit();}
	$row = mysqli_fetch_array($result);
	if($row["password"] != md5(md5($_POST["password"]) . $row["salt"]))
		{echo "-1";exit();}
	echo "1";
?>