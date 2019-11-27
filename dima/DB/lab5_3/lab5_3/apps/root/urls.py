from django.urls import path

from . import views

app_name = 'root'
urlpatterns = [
    path('', views.show_tables, name='show_tables'),
    path('components/', views.show_components, name='root'),
]
