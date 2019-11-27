from django.urls import path

from . import views

app_name = 'root'
urlpatterns = [
    path('', views.show_tables, name='show_tables'),
    path('components/', views.show_components, name='components'),
    path('brands/', views.show_brands, name='brands'),
    path('stocks/', views.show_stocks, name='stocks'),
    path('stock/', views.show_stock, name='stock'),
    path('clients/', views.show_clients, name='clients'),
    path('workers/', views.show_workers, name='workers'),
    path('positions/', views.show_positions, name='positions'),
    path('basket/', views.show_basket, name='basket'),
    path('orders/', views.show_orders, name='orders'),
]
