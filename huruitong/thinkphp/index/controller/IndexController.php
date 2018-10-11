<?php
namespace app\index\controller;
use think\Controller;
use app\common\model\Teacher;

class IndexController extends Controller
{
	public function __construct()
    {
        parent::__construct();
        if (!Teacher::isLogin()) {
            return $this->error('plz login first', url('Login/index'));
        }
    }
    public function index()
    {

    }
}
