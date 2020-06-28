# TestFiles

[![Build Status](https://jadsena.visualstudio.com/TestFiles/_apis/build/status/jadsena.TestFiles?branchName=master)](https://jadsena.visualstudio.com/TestFiles/_build/latest?definitionId=7&branchName=master)
![GitHub](https://img.shields.io/github/license/jadsena/TestFiles?style=flat-square)
![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/jadsena/TestFiles)
![Nuget](https://img.shields.io/nuget/dt/TestFiles)
![GitHub release (latest SemVer)](https://img.shields.io/github/v/release/jadsena/TestFiles)
![Nuget](https://img.shields.io/nuget/v/TestFiles)

## Pré-requisitos

Ter instalado a versão .NET Core 3.1 ou superior.

## Instalação

```dos
C:\>dotnet tool install -g TestFiles
```

## Utilização

```dos
C:\>TestFiles <path> <files> <transaction>
```

### Onde

`Path` -> Diretório onde ocorrerá a busca nos arquivos solicitados.

`Files` -> Tipo dos arquivos que se deseja pesquisar o conteúdo, aceita caracteres especiais "*" e "?".

`Transaction` -> Texto procurado nos arquivos solicitados.

## Arquivo de saída

A ferramenta fará o output do arquivo [`TestFilesOutput.txt`] no diretório informado.