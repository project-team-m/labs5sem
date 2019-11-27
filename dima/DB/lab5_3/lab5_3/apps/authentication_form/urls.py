from django.urls import path

from . import views

app_name = 'main_form'
urlpatterns = [
    path('', views.index, name='index'),
    path('check_user/', views.check_user, name='check_user')
]
