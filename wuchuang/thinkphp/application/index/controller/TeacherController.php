<?php
namespace app\index\controller;   
use app\common\model\Teacher;      // 教师模型
use think\Request;
/**
 * 教师管理   继承think\Controller后就可以用V层对数据包装了
 */
class TeacherController extends IndexController
{
    public function index()
    {
        // 获取查询信息
        $name = input('get.name');

        $pageSize = 5;  // 每页显示五条数据

    	$Teacher = new Teacher();

        // 定制查询信息
        if (!empty($name)) {
            $Teacher->where('name', 'like', '%' . $name . '%');
        }

        // 按条件查询数据并分页
        $teachers = $Teacher->paginate($pageSize, false, [
            'query'=>[
            'name' => $name,
            ],
        ]);

    	// 向V层传递数据
    	$this->assign('teachers', $teachers);

    	// 取回打包后的数据
    	$htmls = $this->fetch();

    	// 将数据返回给用户
    	return $htmls;
    }

    /**
     * 插入新数据
     * @return   html
     * @author 梦云智 http://www.mengyunzhi.com
     */
    public function insert()
    {
        $message = '';    // 提示信息

        try {
            // 接受传入数据
            $postData = Request::instance()->post();

    	    // 实例化Teacher为空对象
    	    $Teacher = new Teacher();

    	    // 为对象赋值
    	    $Teacher->name = $postData['name'];
            $Teacher->username = $postData['username'];
            $Teacher->sex = $postData['sex'];
            $Teacher->email = $postData['email'];

            // 新增对象至数据表
            $result = $Teacher->validate(true)->save();

            // 反馈结果
            if (false === $result) {
                return '新增失败:' . $Teacher->getError();
            } else {
                return $this->success('用户' . $Teacher->name . '新增成功', url('index'));
            }

        // 获取到thinkphp内置异常时
        } catch (\think\Exception\HttpResponseException $e) {
            throw $e;

        // 获取到正常的异常时
        } catch (\Exception $e) {
            
            return $e->getMessage();
        } 

        return $this->error($message);
    }
    public function add()
    {
        try {
            $htmls = $this->fetch();
            return $htmls;
        } catch (\Exception $e) {
            return '系统错误' . $e->getMessage();
        }
    }
    public function test() {
        try {
            throw new \Exception("Error Processing Request", 1);
            return $this->error("系统发生错误");

        // 获取到异常时，向上抛出，交给ThinkPHP处理
        } catch (\think\Exception\HttpResponseException $e) {
            throw $e;

        // 获取到正常的异常时，输出异常
        } catch (\Exception $e) {
            return $e->getMessage();
        }
    }
    public function delete()
    {
        try {
            // 获取pathinfo传入的ID值.
            $Request = Request::instance();

            // 获取ID数据
            $id = Request::instance()->param('id/d'); //"/d表示将数转化为整型"

            // 判断是否成功接受
            if (0 === $id) {
                throw new \Exception("未获取到ID信息", 1);
            }

            // 获取要删除对象
            $Teacher = Teacher::get($id);

            // 删除对象不存在
            if (is_null($Teacher)) {
                return $this->error('不存在id为' . $id . '的教师，删除失败');
            }
            
            // 删除对象
            if (!$Teacher->delete()) {
                return $this->error('删除失败:' . $Teacher->getError());
            }
        
            // 获取到ThinkPHP内置异常时，直接向上抛出，交给PHP处理
        } catch (\think\Exception\HttpResponseException $e) {
            throw $e;

        // 获取到正常的异常时，输出异常
        } catch (\Exception $e) {
            return $e->getMessage();
        }
        // 进行跳转
        return $this->success('删除成功', $Request->header('referer'));
    }
    public function edit()
    {
        try {
            // 获取传入ID
            $id = Request::instance()->param('id/d');

            // 判断是否重新接受
            if (is_null($id) || 0 === $id) {
                throw new \Exception('未获取到ID信息', 1);
            }

            // 在Teacher表模型中获取当前记录
            if (null === $Teacher = Teacher::get($id)) {
                // 由于在$this->error抛出了异常，所以也可以省略return
                $this->error('系统未找到ID为' . $id . '的记录');
            }

            // 将数据传给V层
            $this->assign('Teacher', $Teacher);

            // 获取封装好的V层内容
            $htmls = $this->fetch();

            // 将封装好的V层内容返回给用户
            return $htmls;
        } catch (\think\Exception\HttpResponseException $e) {
            throw $e;

        // 获取到正常的异常时，输出异常
        } catch (\Exception $e) {
            return $e->getMessage();
        } 
    }
    public function update() 
    {
        try {
            // 接受数据，获取要更新的关键字信息
            $id = Request::instance()->post('id/d');

            // 获取当前对象
            $Teacher = Teacher::get($id);

            if (!is_null($Teacher)) {
            
                // 写入要更新的数据
                $Teacher->name = input('post.name');
                $Teacher->username = input('post.username');
                $Teacher->sex = input('post.sex');
                $Teacher->email = input('post.email');

                // 更新
                if (false === $Teacher->validate(true)->save()) {
                    return $this->error('更新失败' . $Teacher->getError());
                }
            } else {
                throw new \Exception("所更新的记录不存在", 1);       // 调用PHP内置类时，需要在前面加上 \
            }
        // 获取到ThinkPHP的内置异常时，直接向上抛出，交给ThinkPHP处理
        } catch (\think\Exception\HttpResponseException $e) {
            throw $e;

        // 获取到正常的异常时，输出异常
        } catch (\Exception $e) {
        
            return $e->getMessage();
        }

        //成功跳转至index触发器
        return $this->success('操作成功', url('index'));
    }
}
