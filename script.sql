USE db_connectamentemvc;

-- 1. DECLARAÇÃO DE TODAS AS VARIÁVEIS (Escopo da Sessão)
SET @id_ana = UUID();
SET @id_bruno = UUID();
SET @id_carla = UUID();
SET @id_lucas = UUID();
SET @id_mariana = UUID();
SET @id_pedro = UUID();
SET @id_julia = UUID();
SET @id_enzo = UUID();
SET @id_beatriz = UUID();
SET @id_thiago = UUID();
SET @id_larissa = UUID();
SET @id_rafael = UUID();

-- 2. INSERÇÃO NA TABELA USUARIO (Psicólogos e Pacientes)
INSERT INTO Usuario 
(Id, Nome, Sobrenome, DataNascimento, Foto, TipoModulo, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount) 
VALUES 
(@id_ana, 'Ana', 'Silva', '2002-05-15', 'avatar1.jpg', 1, 'ana.silva', 'ANA.SILVA', 'ana@email.com', 'ANA@EMAIL.COM', 1, 'HASH', UUID(), UUID(), 0, 0, 1, 0),
(@id_bruno, 'Bruno', 'Oliveira', '1998-10-20', 'avatar2.jpg', 1, 'bruno.oliveira', 'BRUNO.OLIVEIRA', 'bruno@email.com', 'BRUNO@EMAIL.COM', 1, 'HASH', UUID(), UUID(), 0, 0, 1, 0),
(@id_carla, 'Carla', 'Santos', '1995-03-12', 'avatar3.jpg', 1, 'carla.santos', 'CARLA.SANTOS', 'carla@email.com', 'CARLA@EMAIL.COM', 1, 'HASH', UUID(), UUID(), 0, 0, 1, 0),
(@id_lucas, 'Lucas', 'Melo', '1995-03-10', 'p1.jpg', 1, 'lucas.melo', 'LUCAS.MELO', 'lucas@email.com', 'LUCAS@EMAIL.COM', 1, 'HASH', UUID(), UUID(), 0, 0, 1, 0),
(@id_mariana, 'Mariana', 'Luz', '1992-08-22', 'p2.jpg', 1, 'mariana.luz', 'MARIANA.LUZ', 'mariana@email.com', 'MARIANA@EMAIL.COM', 1, 'HASH', UUID(), UUID(), 0, 0, 1, 0),
(@id_pedro, 'Pedro', 'Vaz', '1988-11-05', 'p3.jpg', 1, 'pedro.vaz', 'PEDRO.VAZ', 'pedro@email.com', 'PEDRO@EMAIL.COM', 1, 'HASH', UUID(), UUID(), 0, 0, 1, 0),
(@id_julia, 'Julia', 'Rocha', '2000-01-15', 'p4.jpg', 1, 'julia.rocha', 'JULIA.ROCHA', 'julia@email.com', 'JULIA@EMAIL.COM', 1, 'HASH', UUID(), UUID(), 0, 0, 1, 0),
(@id_enzo, 'Enzo', 'Ribeiro', '2005-05-30', 'p5.jpg', 1, 'enzo.ribeiro', 'ENZO.RIBEIRO', 'enzo@email.com', 'ENZO@EMAIL.COM', 1, 'HASH', UUID(), UUID(), 0, 0, 1, 0),
(@id_beatriz, 'Beatriz', 'Nunes', '1997-07-12', 'p6.jpg', 1, 'beatriz.nunes', 'BEATRIZ.NUNES', 'beatriz@email.com', 'BEATRIZ@EMAIL.COM', 1, 'HASH', UUID(), UUID(), 0, 0, 1, 0),
(@id_thiago, 'Thiago', 'Souza', '1985-09-25', 'p7.jpg', 1, 'thiago.souza', 'THIAGO.SOUZA', 'thiago@email.com', 'THIAGO@EMAIL.COM', 1, 'HASH', UUID(), UUID(), 0, 0, 1, 0),
(@id_larissa, 'Larissa', 'Lima', '1993-12-04', 'p8.jpg', 1, 'larissa.lima', 'LARISSA.LIMA', 'larissa@email.com', 'LARISSA@EMAIL.COM', 1, 'HASH', UUID(), UUID(), 0, 0, 1, 0),
(@id_rafael, 'Rafael', 'Dias', '1999-02-18', 'p9.jpg', 1, 'rafael.dias', 'RAFAEL.DIAS', 'rafael@email.com', 'RAFAEL@EMAIL.COM', 1, 'HASH', UUID(), UUID(), 0, 0, 1, 0);

-- 3. INSERÇÃO NA TABELA PSICOLOGO
INSERT INTO Psicologo (UsuarioId, CRP, Descricao, TipoPerfil)
VALUES 
(@id_ana, 'CRP-01/12345', 'Descrição da Ana - Perfil Coordenador', 1),
(@id_bruno, 'CRP-02/67890', 'Descrição do Bruno - Perfil Estudante', 2),
(@id_carla, 'CRP-03/11223', 'Descrição da Carla - Perfil Clínica', 3);

-- 4. INSERÇÃO NA TABELA PACIENTE
INSERT INTO Paciente (UsuarioId, ContatoEmergencia, HistoricoPaciente)
VALUES 
(@id_lucas, '(11) 9999-0001', 'Faz acompanhamento prévio, ansiedade leve.'),
(@id_mariana, '(11) 9999-0002', 'Uso de medicação para sono, sem diagnósticos prévios.'),
(@id_pedro, '(11) 9999-0003', 'Atividade física regular, busca autoconhecimento.'),
(@id_julia, '(11) 9999-0004', 'Histórico de depressão na família, alimentação irregular.'),
(@id_enzo, '(11) 9999-0005', 'Estudante, queixas de estresse acadêmico.'),
(@id_beatriz, '(11) 9999-0006', 'Dificuldades no trabalho, sem uso de substâncias.'),
(@id_thiago, '(11) 9999-0007', 'Diagnóstico prévio de TDAH, faz uso de ritalina.'),
(@id_larissa, '(11) 9999-0008', 'Pratica yoga, busca melhorar inteligência emocional.'),
(@id_rafael, '(11) 9999-0009', 'Insônia crônica, sem outras queixas físicas.');

-- 5. INSERÇÃO NA TABELA PRONTUARIO
INSERT INTO Prontuario (ProntuarioId, PsicologoResponsavelId, PacienteId, DataCriacao, DataUltimaAtualizacao, Queixas, TipoProntuario)
VALUES 
(UUID(), @id_ana, @id_lucas, NOW(), NOW(), 'Ansiedade relacionada ao trabalho e prazos.', 2),
(UUID(), @id_ana, @id_mariana, NOW(), NOW(), 'Dificuldade de manter o sono e pesadelos recorrentes.', 2),
(UUID(), @id_ana, @id_pedro, NOW(), NOW(), 'Busca de autoconhecimento e transição de carreira.', 2),
(UUID(), @id_bruno, @id_julia, NOW(), NOW(), 'Histórico familiar de depressão e luto recente.', 2),
(UUID(), @id_bruno, @id_enzo, NOW(), NOW(), 'Dificuldade de concentração e agitação.', 1),
(UUID(), @id_bruno, @id_beatriz, NOW(), NOW(), 'Conflitos interpessoais no ambiente corporativo.', 2),
(UUID(), @id_carla, @id_thiago, NOW(), NOW(), 'Gestão de sintomas de TDAH.', 2),
(UUID(), @id_carla, @id_larissa, NOW(), NOW(), 'Aprimoramento de inteligência emocional.', 2),
(UUID(), @id_carla, @id_rafael, NOW(), NOW(), 'Insônia crônica.', 2);

-- 6. INSERÇÃO NA TABELA CONSULTA (Usando subqueries para buscar o ProntuarioId correto)
INSERT INTO Consulta (ConsultaId, DataHoraConsulta, DuracaoConsulta, AnotacoesConsulta, ProntuarioId)
VALUES 
(UUID(), '2026-03-25 14:00:00', '00:50:00', 'Sessão inicial com Thiago.', (SELECT ProntuarioId FROM Prontuario WHERE PacienteId = @id_thiago)),
(UUID(), '2026-03-25 15:00:00', '00:50:00', 'Sessão inicial com Larissa.', (SELECT ProntuarioId FROM Prontuario WHERE PacienteId = @id_larissa)),
(UUID(), '2026-03-25 16:00:00', '00:50:00', 'Sessão inicial com Rafael.', (SELECT ProntuarioId FROM Prontuario WHERE PacienteId = @id_rafael));