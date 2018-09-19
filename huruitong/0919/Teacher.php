<?php
namespace app\index\controller;
use think\Db;

class Teacher
{
    public function index()
    {
    	$teachers = Db::name('teacher')->select();
    	// var_dump($teachers);
    	
    	// var_dump($teachers[0]);

    	// var_dump($teachers[0]['name']);

    	echo $teachers[0]['name'];

    	return $teachers[0]['name'];

    }
}
