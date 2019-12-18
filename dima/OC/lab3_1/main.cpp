#include <unistd.h>
#include <stdio.h>
int main(void)
{
    pid_t pid = fork();
    if(!(access("/usr/bin/python3", F_OK | X_OK))){
        printf( "Доступ на выполнение разрешен\n");
        if (pid==0) {
            execl ("/usr/bin/python3","/usr/bin/python3",NULL);
        }
        perror ("Вызов execl не смог запустить программу python\n");
    }
    else printf ( "атрибут “x” не установлен, выполнение запрещено!\n" );
    return (0)  ;
}