# Generated by Django 2.1.5 on 2019-01-08 03:40

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('community', '0002_auto_20190107_1413'),
    ]

    operations = [
        migrations.RenameField(
            model_name='product',
            old_name='title',
            new_name='name',
        ),
        migrations.RemoveField(
            model_name='product',
            name='cdate',
        ),
    ]
