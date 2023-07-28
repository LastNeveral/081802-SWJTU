//write程序
#include <stdio.h>
#include <sys/types.h>
#include <sys/ipc.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/shm.h>
#include <string.h>
int main() 
{
	//保证当前目录存在a.c文件
    key_t key = ftok("./a.c", 99);
    if(key < 0) 
    {
        perror("ftok");
        exit(1);
    }
   //用于创建共享内存,返回句柄shmid 
    int shmid = shmget(key, 20, IPC_CREAT | 0666 );
    if(shmid < 0) 
    {
        perror("shmid");
        exit(1);
    }
    //将内存映射到用户空间,返回值为void * 
    char *shmp = shmat(shmid, NULL, 0);
    if(shmp < 0) 
    {
        perror("shmat");
        exit(1);
    }
    //往shmp对应地址空间写内容，映射到内核里了，之后由别的程序可以通过此指针在内核里读东西
    char a[30];
    while(1) 
    {
        sleep(1);
        scanf("%s", a);
        if(!strcmp(a, "quit"))
        {
            break;
        }
        snprintf(shmp, 30, "%s\n", a);
    }
    //释放内存
    shmdt(shmp);
    return 0;
}


