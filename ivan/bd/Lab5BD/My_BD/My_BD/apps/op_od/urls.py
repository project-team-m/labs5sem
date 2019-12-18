from django.urls import path

from . import views

app_name = 'op_od'
urlpatterns = [
    path('', views.show_tables, name='show_tables'),
    path('table/', views.show_table, name='show_table'),
    path('table_backup/', views.show_table_old, name='show_table_old'),
    path('enter_table/', views.enter_table, name='enter_table'),
]
