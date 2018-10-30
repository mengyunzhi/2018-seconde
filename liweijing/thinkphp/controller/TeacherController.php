<?php
namespace app\index\controller;
use think\Controller;
use think\Request;
use app\common\model\Teacher;  // 教师模型

/**
 * 教师管理
 */
class TeacherController extends Controller
{
    public function index()
    {
        try {
            // 获取查询信息
            $name = Request::instance()->get('name');
            echo $name;
        $pageSize = 5; // 每页显示5条数据
        // 实例化Teacher
    	$Teacher = new Teacher();
        // 定制查询信息
        if (!empty($name)) {
            $Teacher->where('name','like','%'.$name.'%');
        }
        // 按条件查询数据并调用分页
        $teachers = $Teacher->paginate($pageSize, false,
            [
                'query'=>['name' => $name,]
            ]);
    	// 向V层传递数据
    	$this->assign('teachers', $teachers);
    	// 取回打包后的数据
    	$htmls = $this->fetch();
    	// 将数据返回给用户
    	return $htmls;

        // 获取到ThinkPHP的内置异常时，直接向上抛出，交给ThinkPHP处理
    } catch (\think\Exception\HttpResponseException $e) {
        throw $e;
        // 获取到正常的异常时，输出异常
    } catch(\Exception $e) {
        return $e->getMessage();
    }
    }
    public function insert()
    {
    	$message = '';  // 提示信息

        try{
            // 接收传入数据
    	$postData = Request::instance()->post();

		//实例化Teacher空对象
		$Teacher = new Teacher();
		//为对象属性赋值
		$Teacher->name = $postData['name'];
		$Teacher->username = $postData['username'];
		$Teacher->sex = $postData['sex'];
		$Teacher->email = $postData['email'];
		// 新增对象至数据表
		$result = $Teacher->validate(true)->save($Teacher->getData());
		// 反馈结果
		if (false === $result) {
            // 验证未通过，发生错误
			$message = '新增失败：' . $Teacher->getError();
		} else {
            // 提示操作成功，并跳转至教师管理列表
            return $this->success('用户' . $Teacher->name . '新增成功。',url('index'));
		}
    } catch(\Exception $e) {
        // 发生异常
        return $e->getMessage();
    }
    return $this->error($message);
    }
    public function add()
    {
    	$htmls = $this->fetch();
    	return $htmls;
    }
    public function delete()
    {
    	try {
            // 获取get数据
            $Request = Request::instance();
            $id = Request::instance()->param('id/d');
            
            // 判断是否成功接收
            if (0 === $id) {
                throw new \Exception("未获取到ID信息", 1);
            }

            // 获取要删除的对象
            $Teacher = Teacher::get($id);

            // 要删除的对象存在
            if (is_null($Teacher)) {
                throw new \Exception('不存在id为' . $id . '的教师，删除失败', 1);
            }

            // 删除对象
            if (!$Teacher->delete()) {
                $message = '删除失败:' . $Teacher->getError();
            }

            // 进行跳转
            return $this->success('删除成功', $Request->header('referer')); 
        } catch (\Exception $e) {
            return $e->getMessage();
        }

        return $this->error($message);	
    }
    public function edit()
    {
    	try{
        // 获取传入ID
    	$id = Request::instance()->param('id/d');
    	// 判断是否成功接收
        if (is_null($id) || 0 === $id) {
            throw new \Exception('未获取到ID信息',1);
        }
        // 在Teacher表模型中获取当前记录
        if (null === $Teacher = Teacher::get($id)) {
            // 由于在$this->error抛出了异常，所以也可以省略return（不推荐）
            $this->error('未找到ID为' . $id . '的记录');
        }
    	//将数据传给V层内容
    	$this->assign('Teacher',$Teacher);
    	//获取封装好的数据
    	$htmls = $this->fetch();
    	//将封装好的V层内容返回给用户
    	return $htmls;
        // 获取到ThinkPHP的内置异常时，直接向上抛出，交给ThinkPHP处理
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
            // 接受数据，获取关键字信息 
            $id = Request::instance()->post('id/d');
            // 获取当前对象
            $Teacher = Teacher::get($id);
            if (!is_null($teacher)) {
                // 写入要更新的数据
                $Teacher->name = input('post.name');
                $Teacher->username = input('post.username');
                $Teacher->sex = input('post.sex');
                $Teacher->email = input('post.email');
                // 更新
                if (false === $Teacher->validate(true)->save()) 
                {
                        return $this->error('更新失败' . $Teacher->getError());
                }
            } else {
                throw new \Exception("所更新的记录不存在",1);//调用内置php类时，前边必须加\
            }
            // 获取到php内置异常时，直接向上抛出，交给thinkphp处理
        }
        catch (\think\Exception\HttpResponseException $e){
            // 由于对异常进行了处理，如果发生了错误，我们仍然要查看具体的异常位置和信息，那么需要将以下的代码的注释去掉
            throw $e;
            // 获取到正常的异常时，输出异常
        } catch (\Exception $e) {
            return $e->getMessage();
        }
        // 成功跳转至index触发器
        return $this->success('操作成功',url('index'));
    }
}