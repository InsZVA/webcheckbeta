<?php
//Configures
	include("antiinject.php");
	$bbs="discuz_";			//论坛前缀
	$pre="bbs0_";				//表前缀
	$sqlusername="root";		//MySQL用户名
	$sqlpwd="password";		//MySQL密码
	$count="extcredits1";		//需要使用的积分		

	$con=mysqli_connect("localhost",$sqlusername,$sqlpwd);
	if (!$con)
  	{
  		die('Could not connect: ' . mysql_error());
  	}
	mysqli_select_db($con,$bbs."bbs");
	$result = mysqli_query($con,"SELECT * FROM " . $pre . "ucenter_members WHERE username = \"" . $_POST['user']."\"");
	$row = mysqli_fetch_array($result);
	$result = mysqli_query($con,"SELECT * FROM " . $pre . "common_member_count WHERE uid = " . $row["uid"]);
	if(!$result){echo "0";exit();}
	$row = mysqli_fetch_array($result);
	echo $row[$count];exit(0);
?>