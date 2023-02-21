
# coding=utf-8
#!/usr/bin/env python

import csvtomd
import csv

def read_csv(path):
    with open(path,encoding="utf8") as f:
        return list(csv.reader(f))


def read_file(path):
    with open(path) as f:
        return f.read()

def to_table(filename,mdname, rept=','):
    '''将符号分割文本转化为markdown表格形式    
    parameter:需要转化的文件名(str),文本的分割符号(str)
    '''
    file_obj_r = open(filename, 'r')
    file_obj_w = open(mdname, 'w')
    count = 0  # 哨兵,实现文件的第二行另做处理
    for line in file_obj_r:
        rec = line.split(rept)
        new_rec = [i.strip() for i in rec]
        new_rec = '|'+ '|'.join(new_rec) +'|'+'\n'
        file_obj_w.write(new_rec)
        if count == 0:
            head_rec = '|'
            for i in rec:
                head_rec += '---|'
            head_rec += '\n'
            file_obj_w.write(head_rec)
            count += 1
    file_obj_r.close()
    file_obj_w.close()
 

def test_md_table(csv, md):
    # table = read_csv(csv)
    # #csvtomd.md_table(table)
    # output = csvtomd().md_table(table)
    # print(output)

    with open(csv, "r") as f:
        table = csvtomd.csv_to_table(f, ",")
        print(csvtomd.md_table(table), file=open(md, "a"))


if __name__ == '__main__':
    csvname="/Users/kouko/new.csv"
    mdname=csvname.replace(".csv",".md")
    to_table(csvname,mdname)
