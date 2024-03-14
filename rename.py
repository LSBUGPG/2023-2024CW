# convert Moodle style filenames to bare student numbers
import os, shutil

list = {}
for filename in os.listdir():
	if os.path.isdir(filename):
		split = filename.split('_')
		name = split[0]
		number = split[1]
		type = split[3]
		if (not number in list):
			list[number] = [filename]
		else:
			list[number].append(filename)

# for entry in list:
# 	for folder in list[entry]:
# 		shutil.copytree(folder, entry, dirs_exist_ok=True)

with open('lookup.csv', 'w') as file:
	file.write('Name, Surname, Number\n')
	for entry in list:
		folder = list[entry][0]
		split = folder.split('_')
		number = split[1]
		names = split[0].split(' ')
		firstname = names[0]
		surname = ' '.join(names[1:])
		file.write(f'{firstname}, {surname}, {number}\n')
