from django.urls import path

from . import views

app_name = 'root'
urlpatterns = [
    path('', views.show_tables, name='show_tables'),
    path('table/', views.show_table, name='show_table'),
    path('enter_table/', views.enter_table, name='enter_table'),
]